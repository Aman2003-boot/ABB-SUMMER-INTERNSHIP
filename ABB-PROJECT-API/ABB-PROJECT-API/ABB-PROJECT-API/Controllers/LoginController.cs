using ABB_PROJECT_API.Data;
using ABB_PROJECT_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace ABB_PROJECT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        protected readonly DbProjContext _context;

        public LoginController(DbProjContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult GetLogin()
        {
            var result = _context.TblUser.ToList();
            return Ok("Login endpoint hit successfully. - TEST CHANGE");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid login request.");
            }

            try
            {
                var user = await _context.TblUser
                                   .Where(x => x.Username == request.Email && x.Password == request.Password)
                                   .FirstOrDefaultAsync();

                if (user != null)
                {
                    var token = "your-placeholder-jwt-token";

                    return Ok(new {
                        token = token,
                        user = new {
                            id = user.Id,
                            email = user.Username,
                            fullName = user.Name
                        },
                        message = "Login successful"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred during login.");
            }
            return Unauthorized("Invalid email or password.");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid registration request.");
            }

            var newUser = new User
            {
                Username = request.Email,
                Password = request.Password,
                Name = request.Name,
                CreatedBy = 1,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            var existingUser = await _context.TblUser.FirstOrDefaultAsync(u => u.Username == newUser.Username);
            if (existingUser != null)
            {
                return Conflict(new {
                    message = "This email address is already registered. Please use a different email or try logging in.",
                    status = "error",
                    errorCode = "EMAIL_EXISTS",
                    error = "Email already exists"
                });
            }

            try
            {
                _context.TblUser.Add(newUser);
                await _context.SaveChangesAsync();
                var token = "your-placeholder-jwt-token";

                return Ok(new {
                    token = token,
                    user = new {
                        id = newUser.Id,
                        email = newUser.Username,
                        fullName = ""
                    },
                    message = "Registration successful! You can now login with your credentials.",
                    status = "success"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while registering the user.");
            }
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request?.Email))
            {
                return BadRequest("Email is required.");
            }

            var user = await _context.TblUser.FirstOrDefaultAsync(u => u.Username == request.Email);
            if (user == null)
            {
                // For security, do not reveal if the email exists or not
                return Ok(new { message = "If the email exists, the password has been sent." });
            }

            try
            {
                await SendPasswordEmail(user.Username, user.Password);
                return Ok(new { message = "If the email exists, the password has been sent." });
            }
            catch (Exception) // Changed to catch (Exception) to remove CS0168 warning
            {
                return StatusCode(500, "Failed to send password. Please try again."); // Added return statement here
            }
        }

        private async Task SendPasswordEmail(string toEmail, string password)
        {
            try
            {
                var fromAddress = new MailAddress("amanchandak2003@gmail.com", "ABB PROJECT");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "qwmuyoaichmgjdcw"; // <-- REMINDER: REPLACE THIS with your Gmail App Password
                const string subject = "Your Password";
                string body = $"Your password is: {password}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    await smtp.SendMailAsync(message);
                    Console.WriteLine($"Email sent successfully to {toEmail}"); // Added log
                }
            }
            catch (SmtpException ex) // Catch SmtpException for more detail
            {
                Console.WriteLine($"SMTP Error sending email to {toEmail}: {ex.StatusCode} - {ex.Message}"); // Added log
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw; // Re-throw to propagate the error up to the controller
            }
            catch (Exception ex) // General catch for other exceptions
            {
                Console.WriteLine($"General Error sending email to {toEmail}: {ex.Message}"); // Added log
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                throw; // Re-throw to propagate the error up to the controller
            }
        }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class RegisterRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }

    public class ForgotPasswordRequest
    {
        public string? Email { get; set; }
    }
}


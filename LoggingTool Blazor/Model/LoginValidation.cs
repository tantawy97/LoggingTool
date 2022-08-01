using FluentValidation;
using LoggingTool.Dtos;

namespace LoggingTool.Model
{
    public class LoginValidations : AbstractValidator<LoginDetailsDto>
    {
        public LoginValidations()
        {
            RuleFor(w => w.UserName).
                NotNull().
                NotEmpty().
                WithMessage("Please Enter User Name").
                OverridePropertyName("User Name").
                Length(5, 20).WithMessage("Length of User Name is between 5 to 20").
                Matches(@"^[\S]+$").WithMessage("Enter Valid User Name");


            RuleFor(w => w.Password).
                NotNull().
                NotEmpty().
                WithMessage("Please Enter Your Password").
                Length(8, 20).WithMessage("Length of Password is Must be between 8 to 20");
            RuleFor(w => w.Website).
                NotNull().
                NotEmpty().
                WithMessage("Please Enter WebSite").
                OverridePropertyName("Web Site").
                Length(5, 20).WithMessage("Length of User Name is between 5 to 20").
                Must(w => w?.ToLower().StartsWith("www.") == true && w?.ToLower().EndsWith(".com") == true).
                WithMessage("Please Enter Valid Email");
        }
    }
        public class LoginDtoValidations : AbstractValidator<LoginDto>
        {
            public LoginDtoValidations()
            {
                RuleFor(w => w.Email).
                    NotNull().
                    NotEmpty().
                    WithMessage("Please Enter Your Email").EmailAddress();
                RuleFor(w => w.Password).
                    NotNull().
                    NotEmpty().
                    WithMessage("Please Enter Your Password");
                
            }
            
        }
        }


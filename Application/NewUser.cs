using Club_in_API.UserType.ApplicationDBContext;
using Club_in_API.UserType.Model;
using FluentValidation;
using MediatR;

namespace Club_in_API.UserType.Application
{
    public class NewUser
    {
        public class Execute : IRequest<bool>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string UserType { get; set; }
            public bool IsActive { get; set; }
        }

        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.UserType).NotEmpty();
                RuleFor(x => x.IsActive).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute, bool>
        {
            private readonly UserTypeContext _context;
            public Handler(UserTypeContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Execute request, CancellationToken cancellationToken)
            {
                var user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserType = request.UserType,
                    IsActive = request.IsActive
                };
                _context.User.Add(user);
                var inserction = await _context.SaveChangesAsync();
                if (inserction > 0) return true;
                return false;
            }
        }
    }
}

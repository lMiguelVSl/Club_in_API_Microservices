using Club_in_API.UserType.ApplicationDBContext;
using Club_in_API.UserType.Model;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Club_in_API.UserType.Application
{
    public class GetUser
    {
        public class Execute : IRequest<User>
        {
            public int UserId { get; set; }
        }

        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.UserId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute, User?>
        {
            private readonly UserTypeContext _context;
            public Handler(UserTypeContext context)
            {
                _context = context;
            }

            public async Task<User?> Handle(Execute request, CancellationToken cancellationToken)
            {
                var user = await _context.User.FirstOrDefaultAsync();
                return user == null ? null : user;
            }
        }

    }
}

using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Application.SecurityUtil;
using Common.Common.Application.SecurityUtil;

namespace Club.Application.Users.AdminChangePassword;

public class ChangeUserPasswordCommandHandler(IUserRepository repository) : IBaseCommandHandler<ChangeUserPasswordCommand>
{
    public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();
        if (!request.IsAdmin)
        {
            bool isPasswordCompatible = Sha256Hasher.IsCompare(hashText: user.PasswordHash, request.Password);
            if (!isPasswordCompatible)
            {
                return OperationResult.Error("پسوورد قبلی شما درست نیست");
            }
        }
        if (request.Password != request.RePassword)
            return OperationResult.Error("پسوورد با تکرار پسوورد یکی نیست");
        var passwordHash = Sha256Hasher.Hash(request.Password);

        user.ChangePassword(passwordHash);
        await repository.Save();
        return OperationResult.Success();
    }
}

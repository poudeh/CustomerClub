using Club.Domain.UserAgg;
using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;
using Common.Common.Application.SecurityUtil;

namespace Club.Application.Users.Register;

public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری بودن نام کاربری
        if (await _userRepository.ExistsAsync(x => x.Username == request.UserName))
            return OperationResult.Error("نام کاربری قبلاً ثبت شده است.");
        
        // بررسی تکراری بودن شماره تلفن
        if (await _userRepository.ExistsAsync(x => x.PhoneNumber == request.PhoneNumber))
            return OperationResult.Error("شماره تلفن قبلاً ثبت شده است.");
        
        var user = new User(username: request.UserName, phoneNumber: request.PhoneNumber,
            gender: request.gender, passwordHash: Sha256Hasher.Hash(request.Password), customerId: request.customerId);
        await _userRepository.AddAsync(user);
        await _userRepository.Save();
        return OperationResult.Success();

    }
}
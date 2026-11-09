using Club.Api.Infrastructure.JwtUtil;
using Club.Api.ViewModels.Auth;
using Club.Domain.UserAgg;
using Club.Queries.BaseDtos;
using Club.Queries.Users.DTOs;
using Club.Queries.Users.GetByPhoneNumber;
using Common.Application;
using Common.AspNetCore;
using Common.Common.Application.SecurityUtil;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Club.Api.Controllers;
public class AuthController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
    {
        var authenticatedUser = await _mediator.Send(new GetUserByPhoneNumberQuery(loginViewModel.PhoneNumber));
        if (authenticatedUser == null || !Sha256Hasher.IsCompare(authenticatedUser.UserDto.PasswordHash, loginViewModel.Password))
        {
            var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }

        if (!authenticatedUser.UserDto.IsActive)
        {
            var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
            return CommandResult(result);
        }

        var loginResult = await AddTokenAndGenerateJwt(authenticatedUser);
        return CommandResult(loginResult);
    }

    private Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(AuthenticatedUserDto authenticatedUser)
    {
        try
        {
            var token = JwtTokenBuilder.BuildToken(authenticatedUser, _configuration);
            var refreshToken = Guid.NewGuid().ToString();
            var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
            return Task.FromResult(OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                Token = token,
                RefreshToken = hashRefreshToken
            }));
        }
        catch (Exception exception)
        {
            return Task.FromException<OperationResult<LoginResultDto?>>(exception);
        }
    }



}


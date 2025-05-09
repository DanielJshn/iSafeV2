using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apief
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IIdentityUser _identity;
        private readonly IBankService _bankService;
        public BankController(IIdentityUser identity, IBankService bankService)
        {
            _identity = identity;
            _bankService = bankService;
        }


        [HttpPost]
        public async Task<IActionResult> PostBankAccount(BankAccountDto bankDto)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var createdBankAccount = await _bankService.CreateBancAccountAsync(bankDto, identity.id);
                return Ok(new ApiResponse(success: true, data: createdBankAccount));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetBankAccounts()
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var getBankAccountsData = await _bankService.GetBankAccountsAsync(identity.id);
                return Ok(new ApiResponse(success: true, data: getBankAccountsData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }


        [HttpPut("bankAccountId")]
        public async Task<IActionResult> PutBankAccount(Guid bankId, BankAccountUpdateDto bank)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                var updateBankAccount = await _bankService.UpdateBankAccountAsync(bankId, bank, identity.id);
                return Ok(new ApiResponse(success: true, data: updateBankAccount));

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }

        [HttpDelete("bankAccountId")] 
        public async Task<IActionResult> DeleteBankAccount(Guid bankId)
        {
            try
            {
                var identity = await _identity.GetUserByTokenAsync(User);
                await _bankService.DeleteBankAccountAsync(bankId, identity.id);
                return Ok(new ApiResponse(success: true, data: Ok()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(success: false, message: ex.Message));
            }
        }

    }
}
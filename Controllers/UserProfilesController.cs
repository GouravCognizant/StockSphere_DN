using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere_DN.Data;
using StockSphere_DN.Models.DTOs;
using StockSphere_DN.Models.Entities;

namespace StockSphere_DN.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UserProfilesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]  
        public IActionResult GetAllUserProfiles()
        {
            var allUserProfiles = dbContext.UserProfiles.ToList();

            return Ok(allUserProfiles);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserProfileByID(Guid id)
        {
            var userProfile = dbContext.UserProfiles.Find(id);
            if(userProfile is null)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUserProfile(Guid id, UpdateUserProfile updateUserProfile)
        {
            var userProfile = dbContext.UserProfiles.Find(id);
            if(userProfile is null)
            {
                return NotFound();
            }
            userProfile.FirstName = updateUserProfile.FirstName;
            userProfile.LastName = updateUserProfile.LastName;
            userProfile.Email = updateUserProfile.Email;
            userProfile.PhoneNumber = updateUserProfile.PhoneNumber;
            userProfile.DateOfBirth = updateUserProfile.DateOfBirth;
            userProfile.PermanentAddress = updateUserProfile.PermanentAddress;
            userProfile.TemporaryAddress = updateUserProfile.TemporaryAddress;
            userProfile.BankName = updateUserProfile.BankName;
            userProfile.AccountNumber = updateUserProfile.AccountNumber;
            userProfile.IfscCode = updateUserProfile.IfscCode;
            userProfile.GovernmentID = updateUserProfile.GovernmentID;

            dbContext.SaveChanges();
            return Ok(userProfile);

        }

        [HttpPost]
        public IActionResult AddUserProfile(AddUserProfile addUserProfile) 
        {
            var userProfileEntity = new UserProfile()
            {
                FirstName = addUserProfile.FirstName,
                LastName = addUserProfile.LastName,
                Email = addUserProfile.Email,
                PhoneNumber = addUserProfile.PhoneNumber,
                DateOfBirth = addUserProfile.DateOfBirth,
                PermanentAddress = addUserProfile.PermanentAddress,
                TemporaryAddress = addUserProfile.TemporaryAddress,
                BankName = addUserProfile.BankName,
                AccountNumber = addUserProfile.AccountNumber,
                IfscCode = addUserProfile.IfscCode,
                GovernmentID = addUserProfile.GovernmentID,
            };
            dbContext.UserProfiles.Add(userProfileEntity);
            dbContext.SaveChanges();
            return Ok(userProfileEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUserProfile(Guid id)
        {
            var userProfile = dbContext.UserProfiles.Find(id);
            if (userProfile is null)
            {
                return NotFound();
            }
            dbContext.UserProfiles.Remove(userProfile);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}

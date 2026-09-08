using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NSubstitute;
using Order.API.Controllers.V1;
using Order.Data;
using Order.DTO.Request;
using Order.DTO.Response;
using ProjectCommonCode;

namespace Order.UnitTest
{
    public class UserControllerShould
    {

        private readonly IUserInterface _userInterfacemock;

        private readonly UserController _userControllerMock;
        public UserControllerShould()
        {
            _userInterfacemock= Substitute.For<IUserInterface>();
            _userControllerMock= new UserController(_userInterfacemock);
        }

        #region  GetAll Test Cases


        [Fact]
        public async Task GivenDefaultParameter_WhenGetAll_thenreturnpageresult()
        {

            //Arrange (arrange the fake data her)
            var pageresults = new PageResults<UserResponse>
            {
                PageNumber = 1,
                PageSize = 10,
                TotalNumberOfRecords = 2,

                Results= new List<UserResponse>

                {
                    new UserResponse {Name="Ram", Email="ram@gmail.com"},
                    new UserResponse {Name="Ram1", Email="ram1@gmail.com"}
                }
            };

            _userInterfacemock.GetAll(1, 10, null,null,"desc").Returns(pageresults);



            ///Act 
            ///
            var result= await _userControllerMock.GetAll();


            //Assert

            result.Should().NotBeNull();

            var okResult= result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(pageresults);
        }
        #endregion

        #region GetById Test Case


        [Fact]

        public async Task GivenValidId_WhenGetbyid_Returnwithuser()
        {

            //Arrange


            int userId = 1;

            var expectedUser = new UserResponse
            {
                Name = "John doe",
                Email = "Ram@gmail.com"

            };

            _userInterfacemock.GetById(userId).Returns(expectedUser);


            //Act
            var result= await _userControllerMock.GetById(userId);
            result.Should().NotBeNull();

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(expectedUser);



        }

        #endregion


        #region Create Tests


        [Fact]
        public async Task GivenValidRequest_WhenCreate_ThenReturnWithCreateUser()
        {
            //Arrange

            var userRequest = new UserRequest
            {

                Id=1,
                Name="Ram",
                Email="Ram@gmail.com"
            };


            var expectedResponse = new UserResponse
            {


                Name = "Ram",
                Email = "Ram@gmail.com"
            };

            _userInterfacemock.Create(userRequest).Returns(expectedResponse);

            //Act
            var result= await _userControllerMock.Create(userRequest);
            result.Should().NotBeNull();

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion


        #region Update Tests

        [Fact]
        public async Task GivenValidRequest_whenUpdate_ThenReturnUpdateUSer()
        {

            int userId = 1;

            var userRequest = new UserRequest
            {

                Id = userId,
                Name = "Ram update",
                Email = "Ram@gmail.comupdate"
            };


            var expectedUser = new UserResponse
            {
                Name = "Ram update",
                Email = "Ram@gmail.comupdate"

            };

            _userInterfacemock.Update(userId, userRequest).Returns(expectedUser);


            //Act
            var result= await _userControllerMock.Update(userId, userRequest);

            //Assert
            result.Should().NotBeNull();

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(expectedUser);
        }
        #endregion


        #region Delete Test
        [Fact]
        public async Task GivenValid_WhenDelete_ThenReturnOK()
        {
            //Arrange
            int userId = 1;
            _userInterfacemock.DeleteById(userId).Returns(true);

            //Act

            var result= await _userControllerMock.Delete(userId);


            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<OkResult>();
        }
        #endregion
    }
}
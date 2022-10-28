using Moq;
using Assignment_three.Controllers;
using NUnit.Framework;
using Assignment_three.Services;
using Microsoft.Extensions.Logging;
using Assignment_three.Models;
using Microsoft.AspNetCore.Mvc;

namespace RookiesControllerTest;

public class Tests
{
    private RookiesController _rookiesController;
    private Mock<IPersonService> _personServiceMock;
    private Mock<ILogger<RookiesController>> _loggerMock;
    private static List<PersonModel> _data = new List<PersonModel>{
        new PersonModel
        {
            FirstName = "Tai",
            LastName = "Pham Tien",
            BirthPlace = "Vinh Phuc"
        }
    };

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RookiesController>>();
        _personServiceMock = new Mock<IPersonService>();
        _rookiesController = new RookiesController(_loggerMock.Object, _personServiceMock.Object);
        _personServiceMock.Setup(q => q.GetAll()).Returns(_data);
    }

    [Test]
    public void GetAllMember_Success()
    {
        var result = _rookiesController.Index();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        Assert.IsInstanceOf<List<PersonModel>>(view.ViewData.Model);
        Assert.IsAssignableFrom<List<PersonModel>>(view.ViewData.Model);

        var list = (List<PersonModel>)view.ViewData.Model;

        Assert.AreEqual(1, list.Count());
    }

    [Test]
    public void Create_RedirectToAction()
    {
        _rookiesController.ModelState.AddModelError("FirstName", "Required");

        var result = _rookiesController.Create(model: null);

        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Create_ReturnView()
    {
        var newCreatePerson = new PersonCreateModel()
        {
            FirstName = "Tai",
        };
        var result = _rookiesController.Create(newCreatePerson);

        Assert.IsInstanceOf<RedirectToActionResult>(result);

        var actual = (RedirectToActionResult)result;

        Assert.AreEqual("Index", actual.ActionName);
    }

    [Test]
    public void Update_BadRequest_StateIsValid()
    {
        _rookiesController.ModelState.AddModelError("FistName", "FieldRequired");

        var member = new PersonModel();
        var index = 1;
        var updateMember = new PersonUpdateModel();
        var result = _rookiesController.Update(index, updateMember);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);

        var badRequestResult = (BadRequestObjectResult)result;
        var serialize = (SerializableError)badRequestResult.Value;

        Assert.AreEqual("FistName", serialize.Keys.ToList()[0] as string);

    }

    [Test]
    public void Update_RedirectToAction_StateIsValid()
    {
        var member = new PersonModel();
        var index = 2;
        var updateMember = new PersonUpdateModel()
        {
            FirstName = "T"
        };

        var result = _rookiesController.Update(index, updateMember);

        Assert.IsInstanceOf<RedirectToActionResult>(result);

        var redirectToActionResult = (RedirectToActionResult)result;

        Assert.Null(redirectToActionResult.ControllerName);
        Assert.AreEqual("Index", redirectToActionResult.ActionName);
    }

    [Test]
    public void Detail_RedirectToAction_IsNull()
    {
        int index = 1;
        var result = _rookiesController.Details(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }

    [Test]
    public void Detail_Content_IsNotFound()
    {
        var testId = 3;

        _personServiceMock.Setup(x => x.GetOne(testId)).Returns((PersonModel)null);

        var result = _rookiesController.Details(testId);

        Assert.IsInstanceOf<ContentResult>(result);

        var contentResult = (ContentResult)result;

        Assert.AreEqual("NotFound", contentResult.Content);
    }

    [Test]
    public void DeleteOnePerson_Test()
    {
        int index = 2;
        _personServiceMock.Setup(p => p.Delete(index)).Callback(() =>
        {
            _data.Remove(_data[2]);
        }).Returns(_data[2]);

        var controller = new RookiesController(_loggerMock.Object, _personServiceMock.Object);
        var expected = _data.Count - 1;

        var result = controller.Delete(2);
        var actual = _data.Count;

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, actual);
    }
}
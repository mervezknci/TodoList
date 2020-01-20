using System;
using BLL.UnitofWork;
using BLL.UnitofWork.Interface;
using Entities;
using System.Linq;
using System.Web.Mvc;
using TodoList.UI.Models;

namespace TodoList.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Home
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var repository = unitOfWork.Repository<Todo>();
            var model = repository.GetAll().OrderByDescending(x => x.Id).Select(x => new TodoModel
            {
                Id = x.Id,
                Description = x.Description,
                CreatedDate = x.CreatedDate
            }).ToList();
            return model == null ? null : View(model);
        }

        [HttpPost]
        public ActionResult AddorSetTodo(TodoModel model)
        {
            var repository = unitOfWork.Repository<Todo>();

            if (model.Id != 0)
            {
                var entity = repository.GetById(model.Id);
                entity.Description = model.Description;
                entity.CreatedDate = model.CreatedDate;
                repository.Update(entity);
            }
            else
            {
                var entity = new Todo
                {
                    Description = model.Description,
                    CreatedDate = model.CreatedDate
                };
                repository.Add(entity);
            }
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult RemoveTodo(TodoModel model)
        {
            var repository = unitOfWork.Repository<Todo>();

            repository.Delete(model.Id);

            unitOfWork.Save();

            return Json(new
            {
                IsSuccess = true
            });
        }


        [HttpPost]
        public JsonResult OutDatedTodo()
        {
	        var repository = unitOfWork.Repository<Todo>();

	        var date = DateTime.Now.ToLocalTime();

	        var outDateList = repository.GetAll().Where(x => x.CreatedDate.ToShortDateString() == date.ToShortDateString());
			
			

			return Json(new
			{
				Data= outDateList,
				IsSuccess = true
			});
		}
	}
}

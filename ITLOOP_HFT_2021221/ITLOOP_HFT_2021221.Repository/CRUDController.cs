using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ITLOOP_HFT_2021221.Repository
{
    public class CRUDController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            using (var context = new demoCRUDEntities())
            {
                context.Student.Add(model);

                context.SaveChanges();
            }
            string message = "Created the record successfully";

            ViewBag.Message = message;

            return View();
        }
            [HttpGet]
            public ActionResult
                Read()
            {
                using (var context = new demoCRUDEntities())
                {
                    var data = context.Student.ToList();
                    return View(data);
                }
            }
        public ActionResult Update(int Studentid)
        {
            using (var context = new demoCRUDEntities())
            {
                var data = context.Student.Where(x => x.StudentNo == Studentid).SingleOrDefault();
                return View(data);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Studentid, Student model)
        {
            using (var context = new demoCRUDEntities())
            {
                var data = context.Student.FirstOrDefault(x => x.StudentNo == Studentid);

                if (data != null)
                {
                    data.Name = model.Name;
                    data.Section = model.Section;
                    data.EmailId = model.EmailId;
                    data.Branch = model.Branch;
                    context.SaveChanges();

                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }
        public ActionResult ReadAll()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult
        Delete(int Studentid)
        {
            using (var context = new demoCRUDEntities())
            {
                var data = context.Student.FirstOrDefault(x = > x.StudentNo == Studentid);
                if (data != null)
                {
                    context.Student.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolProject.Models;
using System.Diagnostics;

namespace schoolProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {

            return View();
        }
        //GET : /Teacher/List
        public ActionResult List(string search=null)
        {
            TeacherDataController Controller = new TeacherDataController();
            IEnumerable<Teacher> newTeacher = Controller.ListTeachers(search);
            return View(newTeacher);

        }
        //GET : /Teacher/DeletConfirmation/{id}
         public ActionResult DeletConfirm(int id)
        {      
                TeacherDataController Controller = new TeacherDataController();
                Teacher searchedTeacher = Controller.FindTeacher(id);
            
            return View(searchedTeacher);
        }
        //GET : /Teacher/Shows/
        public ActionResult Shows(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Teacher searchedTeacher = Controller.FindTeacher(id);

            return View(searchedTeacher);
        }
       
        //Get :/Teacher/show/{id}
       
        public ActionResult Show(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Teacher SelectedTeacher = Controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        //Post :/Teacher/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DelTeacher(id);
            return RedirectToAction("List");
        }
        //Get ://Teacher/Add
        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string teacherfname,string teacherlname,string employeenumber,string hiredate,decimal salary)
        {
            Debug.WriteLine("Check Created Method");
            Debug.WriteLine("teacherfname");
            Debug.WriteLine("teacherlname"); 
            Debug.WriteLine("employeenumber");
            Debug.WriteLine("hiredate");
            Debug.WriteLine("salary");

            Teacher NewTeacher = new Teacher();
            NewTeacher.teacherfname = teacherfname;
            NewTeacher.teacherlname = teacherlname;
            NewTeacher.employeenumber= employeenumber;
            NewTeacher.hiredate =hiredate;
            NewTeacher.salary = salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);
            return RedirectToAction("List");
        }
        //Get:Teacher/Update/{id}
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
            return View(SelectedTeacher);
        }
        [HttpPost]
        public ActionResult Update(int id,string teacherfname, string teacherlname, string employeenumber,string hiredate, decimal salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.teacherfname =teacherfname;
            TeacherInfo.teacherlname= teacherlname;
            TeacherInfo.employeenumber = employeenumber;
            TeacherInfo.hiredate = hiredate;
            TeacherInfo.salary = salary;
            TeacherDataController controller = new TeacherDataController();
            controller.TeacherUpdate(id,TeacherInfo);

            return RedirectToAction("Show/"+ id);
        }

    }
}
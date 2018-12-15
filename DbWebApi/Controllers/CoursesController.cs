using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomCursesLibrary.Helpers;
using CustomCursesLibrary.Models;
using DbWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace DbWebApi.Controllers
{
    [Route("db/Courses")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly CoursesContext _coursesContext;

        public CoursesController(CoursesContext context)
        {
            _coursesContext = context;
            if (_coursesContext.Courses.Any()) return;
            _coursesContext.Courses.AddRange(
                new Course
                {
                    Name = "Introduction and learning HTML,CSS",
                    Description = $"Why Learn HTML?{Environment.NewLine}HTML is the foundation of all web pages. Without HTML, you wouldn't be able to organize text or add images or videos to your web pages. HTML is the beginning of everything you need to know to create engaging web pages!{Environment.NewLine}{Environment.NewLine}Take-Away Skills{Environment.NewLine}You will learn all the common HTML tags used to structure HTML pages, the skeleton of all websites. You will also be able to create HTML tables to present tabular data efficiently.",
                    StartTime = DateTime.Now,
                    SubscribedUsers = "N3vix",
                    UsersPoints = "N3vix,50"
                },
                new Course
                {
                    Name = "Learn Python 3",
                    Description = $"Why Learn Python?{Environment.NewLine}Python is a general-purpose, versatile and popular programming language. It's great as a first language because it is concise and easy to read, and it is also a good language to have in any programmer's stack as it can be used for everything from web development to software development and data science applications.{Environment.NewLine}{Environment.NewLine}Take-Away Skills{Environment.NewLine}This course is a great introduction to both fundamental programming concepts and the Python programming language. Python 3 is the most up-to-date version of the language with many improvements made to increase the efficiency and simplicity of the code that you write.",
                    StartTime = DateTime.Now,
                    SubscribedUsers = "N3vix",
                    UsersPoints = "N3vix,50"
                },
                new Course
                {
                    Name = "Introduction and learning JavaScript",
                    Description = $"Why Learn Python?{Environment.NewLine}JavaScript is among the most powerful and flexible programming languages of the web. It powers the dynamic behavior on most websites, including this one.{Environment.NewLine}{Environment.NewLine}Take-Away Skills:{Environment.NewLine}You will learn programming fundamentals and basic object-oriented concepts using the latest JavaScript syntax. The concepts covered in these lessons lay the foundation for using JavaScript in any environment.",
                    StartTime = DateTime.Now,
                    SubscribedUsers = "N3vix",
                    UsersPoints = "N3vix,50"
                },
                new Course
                {
                    Name = "Learn SQL",
                    Description = $"Why Learn SQL?{Environment.NewLine}We live in a data-driven world: people search through data to find insights to inform strategy, marketing, operations, and a plethora of other categories. There are a ton of businesses that use large, relational databases, which makes a basic understanding of SQL a great employable skill not only for data scientists, but for almost everyone.{Environment.NewLine}{Environment.NewLine}Take-Away Skills:{Environment.NewLine}In this course, you'll learn how to communicate with relational databases through SQL. You'll learn—and practice with 4 projects—how to manipulate data and build queries that communicate with more than one table.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Learn C++",
                    Description = $"Why Learn C++?{Environment.NewLine}40 years ago, a Ph.D. student by the name of Bjarne Stroustrup tinkered around with the C programming language, which was and still is a language well-respected for its flexibility and low-level functionality. Little did he know, he created a new language that can now be found in:\r\n\r\nOperating systems\r\nWeb browsers\r\nMicrocontrollers\r\nAAA video games\r\nAnd everywhere else!{Environment.NewLine}{Environment.NewLine}Take-Away Skills:{Environment.NewLine}This course will start with the fundamental programming concepts before digging deeper into the more advanced C++ topics. You will build everything from retro games such as Snake! to a Pokédex with Arduino!",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Introduction to Blockchain",
                    Description = $"Why Learn Blockchain?\r\nBlockchain is a powerful technology with applications in fields such as cryptocurrency, healthcare, insurance, government, music, identification, supply chain, data management, and many more. By understanding the fundamental mechanisms that power blockchain, you can join the conversation and discover use cases for blockchain in your own life and work.\r\n\r\nTake-Away Skills:\r\nIn this course, you\'ll learn the structure and properties of the blockchain itself and the individual blocks that make it up. You\'ll understand the blockchain features that provide security between different blockchain participants. You\'ll visualize different aspects of the blockchain and create and tamper with your own blocks through interactive simulations.\r\n\r\nNotes on Prerequisites:\r\nThe majority of this course requires no prior knowledge. But, if you have some Python experience, you\'ll be able to build a small blockchain library in Python, including a Blockchain class and a Block class. Add functionality to add blocks, create hashes, and verify the chain.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Machine Learning",
                    Description = $"Why Learn Machine Learning?\r\nMachine learning, the field of computer science that gives computer systems the ability to learn from data, is one of the hottest topics in computer science.\r\n\r\nMachine learning is transforming the world: from spam filtering in social networks to computer vision for self-driving cars, the potential applications of machine learning are vast.\r\n\r\nTake-Away Skills:\r\nThis course covers the foundational machine learning algorithms that will help you advance in your career. Whether you’re trying to analyze a dataset using machine learning, or you’re a data analyst trying to upgrade your skills, this course is the best place to start.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Natural Language Processing",
                    Description = $"Why learn NLP?\r\nFrom your virtual assistant recommending a restaurant to that terrible autocorrect you sent your parents, natural language processing (NLP) is a rapidly growing presence in our lives. NLP is all about how computers work with human language. Don’t just use NLP tools — make them!\r\n\r\nTake-Away Skills:\r\nFor now, this course provides an overview of main NLP concepts, and you will build a Python chatbot! But check back later, we will be adding more advanced content soon that will get you to the outcomes that you want!",

                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Learn ReactJS",
                    Description = $"Why Learn ReactJS?\r\nReactJS presents graceful solutions to some of front-end programming\'s most persistent issues. It\'s fast, scalable, flexible, powerful, and has a robust developer community that\'s rapidly growing. There\'s never been a better time to learn React.\r\n\r\nTake-Away Skills:\r\nYou\'ll develop a strong understanding of React\'s most essential concepts: JSX, components, and storing information via props and state. You\'ll be able to combine these ideas in React\'s modular programming style.\r\n\r\nNote on Prerequisites:\r\nA strong foundation in JavaScript is a prerequisite for this course, as well as basic HTML.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Learn Ruby",
                    Description = $"Why Learn Ruby?\r\nRuby is a general-purpose language that is still popular and in high demand in the marketplace, as it\'s more commonly used in Rails applications.\r\n\r\nConcise and readable, it is easy to pick up but also plenty powerful. Companies like Twitter, Soundcloud, Goodreads, and Kickstarter got their products off the ground with Ruby.\r\n\r\nTake-Away Skills:\r\nIn this course, you will gain familiarity with Ruby and basic programming concepts—including variables, loops, control flow, and most importantly, object-oriented programming. You\'ll get a chance to test your understanding in a final project, which you\'ll build locally.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Learn AngularJS",
                    Description = $"Why Learn AngularJS?\r\nAs a web developer, you\'ll need to learn how to use new frameworks on a regular basis. AngularJS is a full-featured framework that is incredibly popular among developers. For single-page applications, the AngularJS framework creates rich interactive features for a real-time experience.\r\n\r\nIt\'s friendly to developers and has a supportive and active community. Products built with AngularJS include YouTube Video Manager, The Weather Channel site, several Google products, and Tinder.\r\n\r\nTake-Away Skills:\r\nApply your understanding of HTML and JavaScript to learn how to build single-page web applications with this popular JavaScript framework. You\'ll be introduced to the Model-View-Controller (MVC) programming pattern and get a chance to build your own application from scratch by the end of this course.\r\n\r\nNote on Prerequisites:\r\nA strong foundation in JavaScript is a prerequisite for this course, as well as basic HTML.",
                    StartTime = DateTime.Now
                },
                new Course
                {
                    Name = "Web Development",
                    Description = $"Why Web Development?\r\nReady to start building polished websites and web applications? Get the skills you need to turn your ideas into reality! This path begins with the basics of HTML but progresses quickly through CSS, JavaScript, and React so that you can go from no-code to full-stack at your own pace at a fraction of the cost of a bootcamp.\r\n\r\nWhat You’ll Learn:\r\nLearn HTML\r\nStyling a Website\r\nGetting Started with JavaScript\r\nGetting More Advanced with Design\r\nJavaScript: Arrays, Loops, and Objects\r\nBuilding Interactive JavaScript Websites\r\nIntroduction to jQuery\r\nIntermediate JavaScript\r\nLearn the Command Line\r\nLearn Git\r\nBuilding Front-end Applications with React\r\nJavaScript Back-End Development\r\nSQL and Databases for Web Development\r\nTest-Driven Development with JavaScript",
                    StartTime = DateTime.Now
                });
            _coursesContext.SaveChanges();
        }

        [HttpGet]
        public ActionResult<List<Course>> GetAll()
        {
            return Ok(_coursesContext.Courses.ToList());
        }

        [HttpGet("Id={id}", Name = "GetCourse")]
        public ActionResult<Course> GetById(long id)
        {
            var item = _coursesContext.Courses.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("Name={name}", Name = "GetCourseByName")]
        public ActionResult<Course> GetByName(string name)
        {
            var item = _coursesContext.Courses.FirstOrDefault(x => string.Equals(
                x.Name,
                name,
                StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Name))
                throw new AppException("Name is required");

            if (_coursesContext.Courses.Any(x => x.Name == course.Name))
                throw new AppException($"Name \\{course.Name}\\ is already taken");

            _coursesContext.Courses.Add(course);
            _coursesContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Course course)
        {
            var newCourse = _coursesContext.Courses.Find(course.Id);

            if (newCourse == null)
                throw new AppException("Course not found");

            if (course.Name != newCourse.Name && _coursesContext.Courses.Any(x => x.Name == course.Name))
                throw new AppException($"Name {course.Name} is already taken");

            if (string.IsNullOrWhiteSpace(course.Description))
                throw new AppException($"Please enter the password");

            newCourse.Name = course.Name;
            newCourse.Description = course.Description;
            newCourse.Lector = course.Lector;
            newCourse.SubscribedUsers = course.SubscribedUsers;
            newCourse.MaximumSubs = course.MaximumSubs;
            newCourse.StartTime = course.StartTime;

            _coursesContext.Courses.Update(newCourse);
            _coursesContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("Id={id}")]
        public IActionResult Delete(long id)
        {
            var course = _coursesContext.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _coursesContext.Courses.Remove(course);
            _coursesContext.SaveChanges();
            return Ok();
        }
    }
}

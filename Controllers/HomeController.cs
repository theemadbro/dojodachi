using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using dojodachi.Models;

namespace dojodachi.Controllers
{
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            if (ret == null)
            {
                Dachi newdachi = new Dachi();
                List<object> dachilist = new List<object>();
                dachilist.Add(newdachi);
                HttpContext.Session.SetObjectAsJson("dachi", dachilist);
                ViewBag.dachi = newdachi;
                return View();
            }
            else
            {
                Dachi dachi = (Dachi)ret[0];
                ViewBag.dachi = dachi;
                // ViewBag.response = TempData["response"];
                return View(TempData["response"]);
            }
        }
        [Route("feed")]
        public IActionResult Feed()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            Dachi dachi = (Dachi)ret[0];
            TempData["response"] = dachi.feed();
            List<object> dachilist = new List<object>();
            dachilist.Add(dachi);
            HttpContext.Session.SetObjectAsJson("dachi", dachilist);
            return RedirectToAction("Index") ;
        }
        [Route("play")]
        public IActionResult Play()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            Dachi dachi = (Dachi)ret[0];
            TempData["response"] = dachi.play();
            List<object> dachilist = new List<object>();
            dachilist.Add(dachi);
            HttpContext.Session.SetObjectAsJson("dachi", dachilist);
            return RedirectToAction("Index") ;
        }
        [Route("work")]
        public IActionResult Work()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            Dachi dachi = (Dachi)ret[0];
            TempData["response"] = dachi.work();
            List<object> dachilist = new List<object>();
            dachilist.Add(dachi);
            HttpContext.Session.SetObjectAsJson("dachi", dachilist);
            return RedirectToAction("Index") ;
        }
        [Route("sleep")]
        public IActionResult Sleep()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            Dachi dachi = (Dachi)ret[0];
            TempData["response"] = dachi.sleep();
            List<object> dachilist = new List<object>();
            dachilist.Add(dachi);
            HttpContext.Session.SetObjectAsJson("dachi", dachilist);
            return RedirectToAction("Index") ;
        }
        [Route("reset")]
        public IActionResult Reset()
        {
            List<Dachi> ret = HttpContext.Session.GetObjectFromJson<List<Dachi>>("dachi");
            Dachi dachi = (Dachi)ret[0];
            dachi.reset();
            List<object> dachilist = new List<object>();
            dachilist.Add(dachi);
            HttpContext.Session.SetObjectAsJson("dachi", dachilist);
            return RedirectToAction("Index") ;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

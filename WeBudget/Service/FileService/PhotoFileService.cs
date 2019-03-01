using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service.FileService
{
    public class PhotoFileService: AbstractClass
    {
        string Name = "Photo";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Photo";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Photo));

        public PhotoFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }
}
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service
{
	public class PhotoService : IPhotoGalery
	{
		PhotoGaleryContext db = new PhotoGaleryContext();
		public  void Delete(int id) {
            Photo b = db.Photos.Find(id);
            if (b != null)
            {
                db.Photos.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(BaseEntity baseEntity) {
            db.Entry((Photo)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity) {
            db.Photos.Add((Photo)baseEntity);
            db.SaveChanges();
        }

        public BaseEntity findById(int? id)
        {
            Photo Photo = db.Photos.Find(id);
            return Photo;
        }

        public  List<BaseEntity> getList()
        {
            List < BaseEntity > baseentity = new List <BaseEntity>();
            List<Photo> Photo = db.Photos.ToList();
            for (int i = 0; i < Photo.Count; i++) {
                baseentity.Add(Photo[i]);
            }
            return baseentity;
        }

    }
}
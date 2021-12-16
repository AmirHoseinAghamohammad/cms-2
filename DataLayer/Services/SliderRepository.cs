using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SliderRepository : ISliderRepository
    {
        private CMSContext DB;
        public SliderRepository(CMSContext context)
        {
            this.DB = context;
        }
        public IEnumerable<Slider> GetAllSlider()
        {
            return DB.Sliders;
        }

        public Slider GetSliderById(int sliderId)
        {
            return DB.Sliders.Find(sliderId);
        }

        public bool InsertSlider(Slider Slider)
        {
            try
            {
                DB.Sliders.Add(Slider);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool UpdateSlider(Slider Slider)
        {
            try
            {
                DB.Entry(Slider).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteById(int sliderId)
        {
            try
            {
                var FindRecord = GetSliderById(sliderId);
                // DB.Entry(FindRecord).State = EntityState.Deleted;
                DB.Sliders.Remove(FindRecord);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            DB.SaveChanges();
        }
        public void Dispose()
        {
            DB.Dispose();
        }
    }
}

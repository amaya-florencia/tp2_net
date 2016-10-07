using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data.Database;
using Business.Entities;


namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }
        ComisionAdapter ca = new ComisionAdapter();


        #region Constructores
        public ComisionLogic()
        {
            ComisionAdapter ComisionData = new ComisionAdapter();
        }
        #endregion

        public List<Comision> GetAll()
        {
            try
            {
                ComisionAdapter ca = new ComisionAdapter();
                return ca.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error GetAll", Ex);
                throw ExcepcionManejada;
            }
        }
        public Comision GetOne(int ID)
        {

            return ca.GetOne(ID);
        }
        public void Delete(int ID)
        {

            ca.Delete(ID);
        }

        public void Save(Comision com)
        {

            ca.Save(com);
        }


    }
}
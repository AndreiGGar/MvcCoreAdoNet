using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctor
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctor()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=sa; Password=";
            this.cn = new SqlConnection (connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText= sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.idDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.idHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string sql = "SELECT DISTINCT Especialidad FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string Especialidad = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(Especialidad);
            }
            this.reader.Close();
            this.cn.Close();
            return especialidades;
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD=@ESPECIALIDAD";
            SqlParameter paramespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            this.com.Parameters.Add(paramespecialidad);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.idDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.idHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctores;
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Test1Model;

namespace Test1Services
{
    public class StudentService:IStudentService
    {
        List<Student> student = new List<Student>();

        public List<Student> GetStudentServices() {
            using (IDbConnection cn = new SqlConnection("Data Source =DESKTOP-UNE5TRI;Initial Catalog=Test1;User ID=sa; password=tommya;"))
            {
                student = cn.Query<Student>("select * from Student").ToList();
            }
            return student;
        }

        public void InsertStudentService(Student student) {
            using (IDbConnection a = new SqlConnection("Data Source =DESKTOP-UNE5TRI;Initial Catalog=Test1;User ID=sa; password=tommya;"))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@ID", student.ID, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@Name", student.Name, dbType:DbType.String, direction:ParameterDirection.Input);
                p.Add("@Age", student.Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
                p.Add("@NIC", student.Age, dbType: DbType.String, direction: ParameterDirection.Input);
                p.Add("@Address", student.Age, dbType: DbType.String, direction: ParameterDirection.Input);

                a.Execute("InsertIntoStudent", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteStudentService(Student student)
        {
            using (IDbConnection a = new SqlConnection("Data Source =DESKTOP-UNE5TRI;Initial Catalog=Test1;User ID=sa; password=tommya;"))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@ID", student.ID, dbType: DbType.String, direction: ParameterDirection.Input);
                a.Execute("DeleteRecord", p, commandType: CommandType.StoredProcedure);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagement.BLL.Services
{
    public class StudentService(IUnitOfWork unitOfWork) : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Student> GetStudentById(Guid studentId, params string[] includes)
        {
            return await _unitOfWork.Students.GetById(studentId, includes);
        }

        public async Task<IEnumerable<Topic>> GetAvailableTopics()
        {
            var topics = (await _unitOfWork.Topics.GetAll())
                .Where(t => !t.Registrations.Any(r => r.Status is RegistrationStatus.Approved))
                .ToList();

            return topics;
        }

        public async Task RegisterGroup(StudentGroup group)
        {
            _unitOfWork.StudentGroups.Add(group);
            await _unitOfWork.Complete();
        }

        public async Task Update(Student student)
        {
            _unitOfWork.Students.Update(student);
            await _unitOfWork.Complete();
        }

        public async Task<Student> GetByStudentIdOrName(string studentIdInput)
        {
            var student = await _unitOfWork.Students.Find(x => x.MSSV.Equals(studentIdInput));
            if(student.Any())
                return student.First();
            return null;
        }
    }
}

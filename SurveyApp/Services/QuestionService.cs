using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;


namespace SurveyApp.Services
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task Add(Question q)
        {
            if (q != null)
            {
                await _context.AddAsync(q);
                await _context.SaveChangesAsync();
            }

        }

        public void Delete(Question q)
        {
            if (q.Id > 0)
            {
                _context.Questions.Remove(q);
                _context.SaveChanges();
            }
        }

        public async Task<List<Question>> GetAll()
        {
            return await _context.Questions.Include(q => q.Answers).ToListAsync();
        }

        public async Task Update(Question q)
        {
            if (q.Id > 0)
            {
                _context.Update(q);
            }
        }

        


    }
}

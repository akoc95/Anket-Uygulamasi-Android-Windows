using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Models;


namespace SurveyApp.Services
{
    public class AnswerService
    {
        private readonly ApplicationDbContext _context;

        public AnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAll()
        {
            return await _context.Answers.ToListAsync();

        }

        public async Task Add(Answer answer)
        {
            if (answer != null)
            {
                await _context.Answers.AddAsync(answer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Update(Answer answer)
        {
            if (answer is not null)
            {
                var existingRecord = await _context.Answers.FirstOrDefaultAsync(a => a.Id == answer.Id);

                if (existingRecord is not null)
                {
                    existingRecord.Title = answer.Title;
                    existingRecord.Point = answer.Point;

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> Delete(Answer answer)
        {
            _context.Answers.Remove(answer);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var deleteComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (deleteComment == null)
            {
                return null;
            }

            _context.Comments.Remove(deleteComment);
            await _context.SaveChangesAsync();
            return deleteComment;
        }

        public async Task<List<Comment>> GetAllAsync(CommentQueryObject query)
        {
            var comments = _context.Comments.Include(a => a.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                comments = comments.Where(s => s.Stock.Symbol.Equals(query.Symbol, StringComparison.CurrentCultureIgnoreCase));
            };

            if (query.IsDesc == true)
            {
                comments = comments.OrderByDescending(c => c.CreatedOn);
            }

            return await comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> GetBySymbolAsync(string symbol)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Stock.Symbol.Equals(symbol, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var updateComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (updateComment == null)
            {
                return null;
            }

            updateComment.Title = commentModel.Title;
            updateComment.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return updateComment;
        }

    }
}
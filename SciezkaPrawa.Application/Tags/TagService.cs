using SciezkaPrawa.Application.Tags.DTOs;
using SciezkaPrawa.Domain.Entities;
using SciezkaPrawa.Domain.Exceptions;
using SciezkaPrawa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Tags
{
    public class TagService(ITagRepository tagRepository) : ITagService
    {
        public async Task<Tag> CreateAsync(SaveTagDto dto)
        {
            var tag = new Tag
            {
                Name = dto.Name
            };

           await tagRepository.AddAsync(tag);
            return tag; 
         }

        public async Task DeleteAsync(int id)
        {
            var tag = await tagRepository.GetByIdAsync(id);

            if (tag is null)
                throw new NotFoundException(nameof(Act), id.ToString());

            await tagRepository.DeleteAsync(tag);
            await tagRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await tagRepository.GetAllAsync();
            return (tags);
        }

        public async Task<Tag?> GetById(int id)
        {
            var tag = await tagRepository.GetByIdAsync(id);

            if (tag == null)
            {
                throw new NotFoundException(nameof(tag), id.ToString());
            }

            return (tag);
        }

        public async Task UpdateAsync(int id, SaveTagDto dto)
        {
            var tag = await tagRepository.GetByIdAsync(id);

            if (tag is null)
                throw new NotFoundException(nameof(Act), id.ToString());

            tag.Name = dto.Name;

            await tagRepository.SaveChangesAsync();
        }
    }
}

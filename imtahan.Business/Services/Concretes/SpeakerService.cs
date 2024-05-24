using imtahan.Business.Exceptions;
using imtahan.Business.Extensions;
using imtahan.Business.Services.Abstracts;
using imtahan.Core.Models;
using imtahan.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Services.Concretes
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _repository;
        private readonly IWebHostEnvironment _env;

        public SpeakerService(ISpeakerRepository repository)
        {
            _repository = repository;
        }

        public void AddSpeaker(Speaker speaker)
        {
            if (speaker == null) throw new FileRequiredException("", "File is required!");

           
            speaker.ImageURL = Helper.SaveFile(_env.WebRootPath, @"\uploads\speakers", speaker.ImageFile);
                     
            _repository.Add(speaker);
            _repository.Commit();


        }

        public List<Speaker> GetAllSpeakers(Func<Speaker, bool>? func = null)
        {
           return _repository.GetAll(func);
        }

        public Speaker GetSpeaker(Func<Speaker, bool>? func = null)
        {
            return _repository.Get(func);
        }

        public void RemoveSpeaker(int id)
        {
            var existSpeaker = _repository.Get(x => x.Id == id);

            if (existSpeaker == null) throw new EntityNotFoundException("", "Speaker is not found!");

            if (existSpeaker.ImageFile != null)
                Helper.DeleteFile(_env.WebRootPath, @"\uploads\speakers", existSpeaker.ImageURL);

            _repository.Delete(existSpeaker);
            _repository.Commit();

        }

        public void UpdateSpeaker(Speaker speaker)
        {

            var existSpeaker = _repository.Get(x => x.Id == speaker.Id);

            if (existSpeaker == null) throw new EntityNotFoundException("", "Speaker is not found!");


            Helper.DeleteFile(_env.WebRootPath, @"\uploads\speakers", existSpeaker.ImageURL);

            existSpeaker.ImageURL = Helper.SaveFile(_env.WebRootPath, @"\uploads\speakers", speaker.ImageFile);

            existSpeaker.Fullname = speaker.Fullname;
            existSpeaker.Description = speaker.Description;

        }
    }
}

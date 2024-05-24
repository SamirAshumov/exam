using imtahan.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Business.Services.Abstracts
{
    public interface ISpeakerService
    {
        void AddSpeaker(Speaker speaker);

        void RemoveSpeaker(int id);

        void UpdateSpeaker(Speaker speaker);

        Speaker GetSpeaker(Func<Speaker, bool>? func = null);

        List<Speaker> GetAllSpeakers(Func<Speaker, bool>? func = null);


    }
}

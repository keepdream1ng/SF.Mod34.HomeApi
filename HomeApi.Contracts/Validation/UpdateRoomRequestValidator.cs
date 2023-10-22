using FluentValidation;
using HomeApi.Contracts.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation
{
	public class UpdateRoomRequestValidator : AbstractValidator<UpdateRoomRequest>
	{
        public UpdateRoomRequestValidator()
        {
            // If property is null it will not be updated.
            RuleFor(r => r.Name).Must(BeSupported)
                .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}");
        }

        private bool BeSupported(string roomName)
        {
            if (roomName == null) return true;
            return Values.ValidRooms.Any(e => e == roomName);
        }
    }
}

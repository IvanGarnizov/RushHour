﻿namespace RushHour.Services
{
    using Entities;

    public interface IAppointmentService : IService<Appointment>
    {
        void Cancel(Appointment appointment);
    }
}

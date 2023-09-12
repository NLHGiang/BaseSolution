﻿namespace BaseSolution.Domain.Entities.Base
{
    public interface IDeletedBase
    {
        public bool Deleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTimeOffset DeletedTime { get; set; }

    }
}

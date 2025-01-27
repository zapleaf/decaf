﻿namespace decaf.Domain.Common;

public interface IEntity
{
    int Id { get; set; }

    string CreatedBy { get; set; }
    DateTime CreatedAt { get; set; }

    string LastModifiedBy { get; set; }
    DateTime LastModifiedAt { get; set; }

    bool IsDeleted { get; set; }
}

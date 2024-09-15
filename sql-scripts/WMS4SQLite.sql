DROP TABLE IF EXISTS "ApprovalStatuses";
DROP TABLE IF EXISTS "Categories";
DROP TABLE IF EXISTS "Changes";
DROP TABLE IF EXISTS "Employees";
DROP TABLE IF EXISTS "Icons";
DROP TABLE IF EXISTS "Priorities";
DROP TABLE IF EXISTS "Projects";
DROP TABLE IF EXISTS "Requests";
DROP TABLE IF EXISTS "RequestTypes";
DROP TABLE IF EXISTS "Roles";
DROP TABLE IF EXISTS "Statuses";
DROP TABLE IF EXISTS "Works";
DROP TABLE IF EXISTS "WorkItems";

-- Employee Table
CREATE TABLE "Employees" (
    "EmployeeId" GUID PRIMARY KEY,
    "LastName" nvarchar (20) NOT NULL,
    "FirstName" nvarchar (20) NOT NULL,
    "Region" nvarchar (15) NULL,
    "Institution" nvarchar (30) NULL,
    "PhoneNumber" nvarchar (24) NULL,
    "Extension" nvarchar (10) NULL,
    "ReportsTo" GUID NULL,
    "Role" GUID NULL,
    "Notes" ntext NULL,
    CONSTRAINT "FK_Employees_Roles" FOREIGN KEY
    (
        "Role"
    ) REFERENCES "Roles" (
        "RoleId"
    )
);
CREATE INDEX "LastName" ON "Employees"("LastName");

-- Categories Table
CREATE TABLE "Categories" (
    "CategoryId" GUID PRIMARY KEY,
    "CategoryName" nvarchar (15) NOT NULL,
    "Description" ntext NULL,
    "Picture" "image" NULL,
);
CREATE INDEX "CategoryName" ON "Categories"("CategoryName");

-- ApprovalStatuses Table
-- Stand alone table to store set values (pending, approved, denied)
CREATE TABLE "ApprovalStatuses" (
    "AprovalStatusId" GUID PRIMARY KEY,
    "ApprovalStatusName" nvarchar(25) NOT NULL,
);
--CREATE INDEX "ApprovalStatusName" ON "ApprovalStatus"("ApprovalStatusName");

-- Priorities Table
-- Stand alone table to store set values (low, standard, high, emergency)
CREATE TABLE "Priorities" (
    "PriorityId" GUID PRIMARY KEY,
    "PriorityName" nvarchar (20) NOT NULL,
);
--CREATE INDEX "PriorityName" ON "Priorities"("PriorityName");

--Request Type
-- Stand alone table to store set values (change request, project request)
CREATE TABLE "RequestTypes" (
    "RequestTypeId" GUID PRIMARY KEY,
    "RequestTypeName" NVARCHAR (25) NOT NULL,
);

--Roles 
--Table to store set values, can be used many times to a record
--(staff, change manager, project manager, board member, admin)
CREATE TABLE  "Roles" (
    "RoleId" GUID PRIMARY KEY,
    "RoleName" NVARCHAR (25) NOT NULL,
);
CREATE INDEX "EmployeeRole" ON "Roles"("RoleName");

--Status
-- Stand alone table to store set values (in progess, on hold, cancelled, completed, pending)
CREATE TABLE "Statuses" (
    "StatusId" GUID PRIMARY KEY,
    "StatusName" NVARCHAR (25) NOT NULL,
);

--Request
--Table for a request submitted by an employee
CREATE TABLE "Requests" (
    "RequestId" GUID PRIMARY KEY,
    "RequestTypeId" GUID NULL,
    "StatusId" GUID NULL,
    "ApprovalStatusId" GUID NULL,
    "EmployeeId" GUID NULL,
    "RequestTitle" NVARCHAR (40) NOT NULL,
    "Description" NTEXT NULL,
    "IsNew" BIT NULL,
    CONSTRAINT "FK_Requests_Employees" FOREIGN KEY
    (
        "EmployeeId"
    ) REFERENCES "Employees" (
        "EmployeeId"
    ),
    CONSTRAINT "FK_Requests_RequestTypes" FOREIGN KEY
    (
        "RequestTypeId"
    ) REFERENCES "RequestTypes" (
        "RequestTypeId"
    ),
    CONSTRAINT "FK_Requests_Statuses" FOREIGN KEY
    (
        "StatusId"
    ) REFERENCES "Statuses" (
        "StatusId"
    ),
    CONSTRAINT "FK_Requests_ApprovalStatuses" FOREIGN KEY
    (
        "ApprovalStatusId"
    ) REFERENCES "ApprovalStatuses" (
        "ApprovalStatusId"
    )
);
CREATE INDEX "EmployeeId" ON "Requests"("EmployeeId");
CREATE INDEX "EmployeesRequests" ON "Requests"("EmployeeId");

CREATE TABLE "Projects" (
    "ProjectId" GUID PRIMARY KEY,
    "StatusId" GUID NULL,
    "ApprovalStatusId" GUID NULL,
    "Requestor" GUID NULL,
    "Request" GUID NUll,
    "CategoryId" GUID NULL,
    "PriorityId" GUID NULL,
    "Work" GUID NULL,
    "ProjectName" NVARCHAR (50) NOT NULL,
    "Description" NTEXT NULL, 
    CONSTRAINT "FK_Projects_Status" FOREIGN KEY
    (
        "StatusId"
    ) REFERENCES "Statuses" (
        "StatusId"
    ),
    CONSTRAINT "FK_Projects_ApprovalStatuses" FOREIGN KEY
    (
        "ApprovalStatusId"
    ) REFERENCES "ApprovalStatuses" (
        "ApprovalStatusId"
    ),
    CONSTRAINT "FK_Projects_Priorities" FOREIGN KEY
    (
        "PriorityId"
    ) REFERENCES "Priorities" (
        "PriorityId"
    ),
    CONSTRAINT "FK_Projects_Employees" FOREIGN KEY
    (
        "Requestor"
    ) REFERENCES "Employees" (
        "EmployeeId"
    ),
    CONSTRAINT "FK_Projects_Requests" FOREIGN KEY
    (
        "Request"
    ) REFERENCES "Requests" (
        "RequestId"
    ),
    CONSTRAINT "FK_Projects_Categories" FOREIGN KEY
    (
        "CategoryId"
    ) REFERENCES "Categories" (
        "CategoryId"
    ),
    CONSTRAINT "FK_Projects_Works" FOREIGN KEY
    (
        "Work"
    ) REFERENCES "Works" (
        "WorkId"
    )
);
CREATE INDEX "CategoriesProjects" ON "Projects"("CategoryId");
CREATE INDEX "CategoryId" ON "Projects"("CategoryId");
CREATE INDEX "EmployeesProjects" ON "Projects"("Requestor");
CREATE INDEX "RequestsProjects" ON "Projects"("Request");
CREATE INDEX "WorksProjects" ON "Projects"("Work");

CREATE TABLE "Changes" (
    "ChangeId" GUID PRIMARY KEY,
    "PriorityId" GUID NULL,
    "StatusId" GUID NULL,
    "CategoryId" GUID NULL,
    "Request" GUID NULL,
    "Requestor" GUID NULL,
    "ApprovalStatusId" GUID NULL,
    "Work" GUID NULL,
    "ChangeName" NVARCHAR (50) NOT NULL,
    "Description" NTEXT NULL,
    CONSTRAINT "FK_Changes_Status" FOREIGN KEY
    (
        "StatusId"
    ) REFERENCES "Statuses" (
        "StatusId"
    ),
    CONSTRAINT "FK_Changes_ApprovalStatuses" FOREIGN KEY
    (
        "ApprovalStatusId"
    ) REFERENCES "ApprovalStatuses" (
        "ApprovalStatusId"
    ),
    CONSTRAINT "FK_Changes_Priorities" FOREIGN KEY
    (
        "PriorityId"
    ) REFERENCES "Priorities" (
        "PriorityId"
    ),
    CONSTRAINT "FK_Changes_Requests" FOREIGN KEY
    (
        "Request"
    ) REFERENCES "Requests" (
        "RequestId"
    ),
    CONSTRAINT "FK_Changes_Categories" FOREIGN KEY
    (
        "CategoryId"
    ) REFERENCES "Categories" (
        "CategoryId"
    ),
    CONSTRAINT "FK_Changes_Employees" FOREIGN KEY
    (
        "Requestor"
    ) REFERENCES "Employees" (
        "EmployeeId"
    ),
    CONSTRAINT "FK_Changes_Works" FOREIGN KEY
    (
        "Work"
    ) REFERENCES "Works" (
        "WorkId"
    )
);
CREATE INDEX "CategoriesChanges" ON "Changes"("CategoryId");
CREATE INDEX "CategoryId" ON "Changes"("CategoryId");
CREATE INDEX "EmployeesChanges" ON "Changes"("Requestor");
CREATE INDEX "RequestsChanges" ON "Changes"("Request");
CREATE INDEX "WorksChanges" ON "Changes"("Work");

CREATE TABLE "Works" (
    "WorkId" GUID PRIMARY KEY
    "Project" GUID NULL,
    "Change" GUID NULL,
    "WorkItem" GUID NULL,
    "Name" NVARCHAR (50),
    CONSTRAINT "FK_Works_Projects" FOREIGN KEY
    (
        "Project"
    ) REFERENCES "Projects" (
        "ProjectId"
    ),
    CONSTRAINT "FK_Works_Changes" FOREIGN KEY
    (
        "Change"
    ) REFERENCES "Changes" (
        "ChangeId"
    ),
    CONSTRAINT "FK_WorksWorkItems" FOREIGN KEY
    (
        "WorkItem"
    ) REFERENCES "WorkItems" (
        "WorkItemId"
    )
);
CREATE INDEX "WorksProjects" ON "Works"("Project");
CREATE INDEX "WorksChanges" ON "Works"("Change");
CREATE INDEX "WorksWorkItems" ON "Works"("WorkItems");

CREATE TABLE "WorkItems" (
    "WorkItemId" GUID PRIMARY KEY,
    "WorkId" GUID NULL,
    "PriorityId" GUID NULL,
    "Assignee" GUID NULL,
    "CardIDNum" NVARCHAR (10) NULL,
    "Header" NVARCHAR (25) NULL,
    "Title" NVARCHAR (25) NULL,
    "Description" NTEXT NULL,
    "StartDate" DATETIME2 NULL,
    "EndDatae" DATETIME2 NULL,
    CONSTRAINT "FK_WorkItems_Priorities" FOREIGN KEY
    (
        "PriorityId"
    ) REFERENCES "Priorities" (
        "PriorityId"
    ),
    CONSTRAINT "FK_WorkItems_Employee" FOREIGN KEY
    (
        "Assignee"
    ) REFERENCES "Employees" (
        "EmployeeId"
    ),
    CONSTRAINT "FK_WorkItems_ Works" FOREIGN KEY
    (
        "WorkId"
    ) REFERENCES "Works" (
        "WorkId"
    )
);
CREATE INDEX "WorkItemsWork" ON "WorkItems"("WorkId");

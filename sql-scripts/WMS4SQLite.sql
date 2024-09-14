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




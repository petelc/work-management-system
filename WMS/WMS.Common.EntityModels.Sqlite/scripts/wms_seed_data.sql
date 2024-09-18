INSERT INTO ApprovalStatuses
    ( ApprovalStatusName, ApprovalStatusId)
VALUES
    ('PENDING', 'cd641f07-768e-4623-8d4c-69bc7140fd4c'),
    ('APPROVED', '0b6faa7b-9863-4637-9c9f-6f1ca564f6a5'),
    ('DENIED', '6d4a77de-b8ba-48f4-9c03-90bdfa5e4650');

INSERT INTO Categories
    (
    Picture,
    Description,
    CategoryName,
    CategoryId
    )
VALUES
    (
        NULL,
        'Category for any development projects/changes',
        'Application Development',
        'df29d65e-80e1-4117-b518-a3f2a64c76a3'
                       ),
    (
        NULL,
        'Category for any security projects/changes',
        'Security',
        '3df85e26-a7ff-41d5-8987-83182cc87743'
                       ),
    (
        NULL,
        'Category for any infrastructure projects/changes',
        'Infrastructure',
        '673500e7-ff17-43ef-aa44-dac9dc686f4a'
                       ),
    (
        NULL,
        'Category for any communication projects/changes',
        'Communications',
        'f77e3353-0ec5-46bd-86df-592e1257e5fe'
                       ),
    (
        NULL,
        'Category for any help desk projects/changes',
        'Help Desk',
        'a6b88b8b-efbd-4540-8db2-3aed601cd33c'
                       ),
    (
        NULL,
        'Category for any desktop support projects/changes',
        'Desktop Support',
        'e7fbcec9-3125-489e-94c0-f844f9d43a36'
                       ),
    (
        NULL,
        'Category for any video support projects/changes',
        'Video Support ',
        '0083dd8e-520a-41e3-bac2-7f2845789f98'
                       );

INSERT INTO Employees
    (
    Notes,
    Role,
    ReportsTo,
    Extension,
    PhoneNumber,
    Institution,
    Region,
    FirstName,
    LastName,
    EmployeeId
    )
VALUES
    (
        NULL,
        '62827e39-1e8e-4341-93b9-b3f533182d31',
        NULL,
        12345,
        '614-555-1234',
        'Operation Support Center',
        'Southeast',
        'Zoey',
        'Richardson',
        '296f0b15-b652-46b6-b0d3-1d1e0b9faa4e'
                      ),
    (
        NULL,
        '62827e39-1e8e-4341-93b9-b3f533182d31',
        NULL,
        98765,
        '380-555-5555',
        'Northeast Correction Institution',
        'Northeast',
        'Frank',
        'Herbert',
        '48ea66d2-33e6-4e88-8b28-c10d000efbd2'
                      );


INSERT INTO Priorities
    (
    PriorityName,
    PriorityId
    )
VALUES
    (
        'LOW',
        'e86c3e8e-0f53-4d83-8d35-dde57845bd1d'
                       ),
    (
        'STANDARD',
        '3abdc851-7768-40fc-a606-a00d10fd3580'
                       ),
    (
        'HIGH',
        '9d7c0dae-a077-424b-b91c-0b9edc2dd17c'
                       ),
    (
        'EMERGENCY',
        '5d3efaf1-e110-484a-a4b2-8d80542e50ae'
                       );

INSERT INTO Requests
    (
    IsNew,
    Description,
    RequestTitle,
    EmployeeId,
    ApprovalStatusId,
    StatusId,
    RequestTypeId,
    RequestId
    )
VALUES
    (
        1,
        'Add new ports to switches for Cameras',
        'Network Switch Change',
        '296f0b15-b652-46b6-b0d3-1d1e0b9faa4e',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '5996e893-daa2-4d8b-a0a7-b573ed814271',
        '7338d383-1f01-4924-b40e-b9c922d654c7'
                     ),
    (
        1,
        'Change screen abcdef title to NEW TITLE',
        'Title change to DOTS screen',
        '48ea66d2-33e6-4e88-8b28-c10d000efbd2',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '5996e893-daa2-4d8b-a0a7-b573ed814271',
        '58e5079e-9392-4969-8a79-a53172a64eb4'
                     ),
    (
        1,
        'Create a data sharing api for application data',
        'Data sharing pipeline',
        '296f0b15-b652-46b6-b0d3-1d1e0b9faa4e',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '284c11b3-1a4c-4e77-98c5-00865e43a420',
        'f4cd4531-a2bd-4d86-aa06-4a2c8a86acdf'
                     ),
    (
        1,
        'Create an application to pull data from legacy forms database',
        'Legacy Forms data request application',
        '48ea66d2-33e6-4e88-8b28-c10d000efbd2',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '284c11b3-1a4c-4e77-98c5-00865e43a420',
        '3a09bd3f-27e0-4a25-833e-ae47e0b12e81'
                     );

INSERT INTO RequestTypes
    (
    RequestTypeName,
    RequestTypeId
    )
VALUES
    (
        'Change Request',
        '5996e893-daa2-4d8b-a0a7-b573ed814271'
                         ),
    (
        'Project Request',
        '284c11b3-1a4c-4e77-98c5-00865e43a420'
                         );


INSERT INTO Roles
    (
    RoleName,
    RoleId
    )
VALUES
    (
        'developer',
        'a662dd5d-b255-482d-aa9a-4e2b6db6d8f0'
                  ),
    (
        'technician',
        '964ad65a-cb9b-445f-b693-8a642c30f3ed'
                  ),
    (
        'staff',
        '62827e39-1e8e-4341-93b9-b3f533182d31'
                  ),
    (
        'change manager',
        '0eefd84b-5c5f-40c1-b6d8-d7496ba92a87'
                  ),
    (
        'project manager',
        '882f01c0-0997-4ad2-9015-884dfc3ec6be'
                  ),
    (
        'board member',
        '2f875921-750a-42f8-9f1c-a564040d199b'
                  ),
    (
        'administrator',
        '3450b12f-b18b-41d7-b2b9-b42a2d9dbe66'
                  );

INSERT INTO Statuses
    (
    StatusName,
    StatusId
    )
VALUES
    (
        'IN-PROGRESS',
        'f30a4fa7-7b3e-46ab-bc2e-a9bef5c736a0'
                     ),
    (
        'ON-HOLD',
        'e66e2ef9-ba0f-4492-8f2f-ac67ad6f4288'
                     ),
    (
        'CANCELLED',
        '8842f405-67e7-4aed-a4ea-b9366db90c7c'
                     ),
    (
        'COMPLETED',
        'e529c970-4c89-4d36-955b-befd9913c4e0'
                     ),
    (
        'PENDING',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621'
                     );


INSERT INTO Changes
    (
    Description,
    ChangeName,
    ApprovalStatusId,
    Requestor,
    Request,
    CategoryId,
    StatusId,
    PriorityId,
    ChangeId
    )
VALUES
    (
        NULL,
        'Title Change',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        '296f0b15-b652-46b6-b0d3-1d1e0b9faa4e',
        '58e5079e-9392-4969-8a79-a53172a64eb4',
        'df29d65e-80e1-4117-b518-a3f2a64c76a3',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        'e86c3e8e-0f53-4d83-8d35-dde57845bd1d',
        'aefdb088-40b1-41aa-9e93-4abf9232bc9f'
                    ),
    (
        NULL,
        'Network Ports',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        '48ea66d2-33e6-4e88-8b28-c10d000efbd2',
        '7338d383-1f01-4924-b40e-b9c922d654c7',
        '3df85e26-a7ff-41d5-8987-83182cc87743',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '3abdc851-7768-40fc-a606-a00d10fd3580',
        '5df4bede-8bbe-4a66-9845-f159db4d6473'
                    );

INSERT INTO Projects
    (
    Description,
    ProjectName,
    PriorityId,
    CategoryId,
    Request,
    Requestor,
    ApprovalStatusId,
    StatusId,
    ProjectId
    )
VALUES
    (
        NULL,
        'Data Pipeline API',
        '3abdc851-7768-40fc-a606-a00d10fd3580',
        'df29d65e-80e1-4117-b518-a3f2a64c76a3',
        'f4cd4531-a2bd-4d86-aa06-4a2c8a86acdf',
        '296f0b15-b652-46b6-b0d3-1d1e0b9faa4e',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '193ca7a4-b58a-48b6-87c2-1eb547dcac58'
                     ),
    (
        NULL,
        'Forms Data API',
        '9d7c0dae-a077-424b-b91c-0b9edc2dd17c',
        'df29d65e-80e1-4117-b518-a3f2a64c76a3',
        '3a09bd3f-27e0-4a25-833e-ae47e0b12e81',
        '48ea66d2-33e6-4e88-8b28-c10d000efbd2',
        'cd641f07-768e-4623-8d4c-69bc7140fd4c',
        'b4e5ef0e-564c-4e55-99c6-e63c71b91621',
        '01a3f1ee-600b-425c-9716-ace2837e7ca6'
                     );

INSERT INTO Works
    (
    Name,
    WorkItem,
    Change,
    Project,
    WorkId
    )
VALUES
    (
        'API Development',
        NULL,
        NULL,
        '193ca7a4-b58a-48b6-87c2-1eb547dcac58',
        'cb86ae20-c19e-453b-b86e-4c7abc9c416d'
                  ),
    (
        'Camera Ports',
        NULL,
        '5df4bede-8bbe-4a66-9845-f159db4d6473',
        NULL,
        '0f26d101-3b91-4314-8922-8aa681b68041'
                  );


INSERT INTO WorkItems
    (
    EndDatae,
    StartDate,
    Description,
    Title,
    Header,
    CardIDNum,
    Assignee,
    PriorityId,
    WorkId,
    WorkItemId
    )
VALUES
    (
        NULL,
        '10/01/2024',
        'Create Base Solution and add API Project',
        'Create API Project',
        'API ',
        13457,
        NULL,
        'e86c3e8e-0f53-4d83-8d35-dde57845bd1d',
        'cb86ae20-c19e-453b-b86e-4c7abc9c416d',
        '3b2b3ab3-a1d7-4b4e-8daa-d90c3802a718'
                      ),
    (
        NULL,
        '10/15/2024',
        'Create Database for API project',
        'Create DB for API',
        'DB',
        65789,
        NULL,
        '3abdc851-7768-40fc-a606-a00d10fd3580',
        '0f26d101-3b91-4314-8922-8aa681b68041',
        '0774b717-1478-4354-871b-a2127b7deb04'
                      ),
    (
        NULL,
        '10/5/2024',
        'Configure VLAN for new Cameras',
        'Create VLAN for camera network',
        'VLAN',
        72640,
        NULL,
        '3abdc851-7768-40fc-a606-a00d10fd3580',
        'cb86ae20-c19e-453b-b86e-4c7abc9c416d',
        '79e87856-dcf7-4e78-995e-02071a6b4b20'
                      ),
    (
        NULL,
        '10/6/2024',
        'Configure Ports in switches',
        'Configure Ports',
        'Ports',
        24612,
        NULL,
        'e86c3e8e-0f53-4d83-8d35-dde57845bd1d',
        '0f26d101-3b91-4314-8922-8aa681b68041',
        '551edc9c-c2ba-4510-9248-ecdd339348e7'
                      );




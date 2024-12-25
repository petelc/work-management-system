export interface Board {
  cabId: number;
  requestName: string;
  votes: string;
  request: {
    requestId: number;
    requestTitle: string;
    priority: string;
    requestTypeName: string;
    requestorUsername: string;
    requestor: {
      employeeId: number;
      displayName: string;
      lastName: string;
      firstName: string;
    };
    approvalStatus: {
      approvalStatusId: number;
      approvalStatusName: string;
    };
    createDate: string;
    requestType: {
      requestTypeId: number;
      requestTypeName: string;
    };
  };
  member: string; // I think I need to build in the member<Employee> object here
  change: string; // I think I need to build in the change object here
  project: string; // I think I need to build in the project object here
  createDate: Date;
  isActive: boolean;
}

export interface BoardParams {
  orderBy: string;
  searchTerm?: string;
  pageNumber: number;
  pageSize: number;
}

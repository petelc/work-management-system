//
export interface Request {
  requestId: number;
  requestTitle: string;
  priority: string;
  requestTypeName: string;
  requestorUsername: string;
  approvalStatus: {
    approvalStatusId: number;
    approvalStatusName: string;
  };
  createDate: string;
  requestType: {
    requestTypeId: number;
    requestTypeName: string;
  }; // Remove optional type
}

export interface RequestParams {
  orderBy: string;
  searchTerm?: string;
  requestType: {
    requestTypeId: number;
    requestTypeName: string;
  };
  approvalStatus: {
    approvalStatusId: number;
    approvalStatusName: string;
  };
  pageNumber: number;
  pageSize: number;
}

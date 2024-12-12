//
export interface Request {
  requestId: number;
  requestTitle: string;
  priority: string;
  requestTypeName: string;
  requestorUsername: string;
  approvalStatusName: string;
  createDate: string;
  requestType: string; // Remove optional type
}

export interface RequestParams {
  orderBy: string;
  searchTerm?: string;
  types: string;
  approvalStatus: string;
  pageNumber: number;
  pageSize: number;
}

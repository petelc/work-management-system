export interface Request {
  id: number;
  requestId: number;
  requestTitle: string;
  description: string;
  requestType?: string;
  approvalStatus?: string;
  status?: string;
  isNew?: boolean;
  requestors?: string[];
}

export interface RequestParams {
  orderBy: string;
  searchTerm?: string;
  types: string[];
  approvalStatus: string[];
  pageNumber: number;
  pageSize: number;
}

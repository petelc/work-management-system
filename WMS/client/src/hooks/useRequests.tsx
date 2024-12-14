import { useEffect } from 'react';
import {
  requestSelectors,
  fetchFilters,
  fetchRequestsAsync,
} from '../pages/request/requestSlice';
import { useAppSelector, useAppDispatch } from '../store/hooks';
//import { Request } from '../models/request';

type ApprovalStatus = {
  approvalStatusId: number;
  approvalStatusName: string;
};

type RequestType = {
  requestTypeName: string;
};

type RequestState = {
  requests: any;
  approvalStatus: ApprovalStatus | {};
  types: RequestType | string;
  requestsLoaded: boolean;
  filtersLoaded: boolean;
  metaData: any;
};

export default function useRequests(): RequestState {
  const requests = useAppSelector(requestSelectors.selectAll);
  const {
    requestsLoaded,
    filtersLoaded,
    approvalStatus,
    requestType,
    metaData,
  } = useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

  const approvalStatusName =
    typeof approvalStatus === 'string' ? approvalStatus : approvalStatus;
  const requestTypeName =
    typeof requestType === 'string' ? requestType : requestType;

  useEffect(() => {
    if (!requestsLoaded) dispatch(fetchRequestsAsync());
  }, [requestsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [dispatch, filtersLoaded]);

  return {
    requests,
    requestsLoaded,
    filtersLoaded,
    approvalStatus: approvalStatusName,
    types: requestTypeName,
    metaData,
  };
}

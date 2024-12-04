import { useEffect } from 'react';
import {
  requestSelectors,
  fetchRequestsAsync,
  fetchFilters,
} from '../pages/request/requestSlice';
import { useAppSelector, useAppDispatch } from '../store/configureStore';
//import { Request } from '../models/request';

type ApprovalStatus = {
  approvalStatusName: string;
};

type RequestType = {
  requestTypeName: string;
};

type RequestState = {
  requests: any;
  approvalStatus: ApprovalStatus | string;
  types: RequestType | string;
  requestsLoaded: boolean;
  filtersLoaded: boolean;
  metaData: any;
};

export default function useRequests(): RequestState {
  const requests = useAppSelector(requestSelectors.selectAll);
  const { requestsLoaded, filtersLoaded, approvalStatus, types, metaData } =
    useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

  console.log(requests);

  const approvalStatusName =
    typeof approvalStatus === 'string' ? approvalStatus : approvalStatus;
  const requestTypeName = typeof types === 'string' ? types : types;

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

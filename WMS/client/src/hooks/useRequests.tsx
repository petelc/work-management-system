import { useEffect } from 'react';
import {
  requestSelectors,
  fetchRequestsAsync,
  fetchFilters,
} from '../pages/request/requestSlice';
import { useAppSelector, useAppDispatch } from '../store/configureStore';

export default function useRequests() {
  const requests = useAppSelector(requestSelectors.selectAll);
  const { requestsLoaded, filtersLoaded, approvalStatus, types, metaData } =
    useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

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
    approvalStatus,
    types,
    metaData,
  };
}

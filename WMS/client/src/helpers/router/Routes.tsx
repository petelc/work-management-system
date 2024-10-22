import { createBrowserRouter } from 'react-router-dom';

import App from '../../layouts/App';
import RequestPage from '../../pages/request/RequestPage';
import Request from '../../pages/request/Request';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      { path: 'request', element: <RequestPage /> },
      { path: 'requestList', element: <Request /> },
    ],
  },
]);

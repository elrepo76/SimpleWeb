import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Login  from "./components/Login";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  }
  //{
  //  path: '/counter',
  //  element: <Counter />
  //},
  //{
  //  path: '/fetch-data',
  //  element: <FetchData />
  //}
];

export default AppRoutes;

import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import Alert from "./pages/Alert";

export default function Routes() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/" exact component={Alert} />
      </Switch>
    </BrowserRouter>
  );
}

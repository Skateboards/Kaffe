import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import { Shops_SelectAll } from "./Services/kaffeService";

class App extends Component {
  state = {
    shops: []
  };

  async componentDidMount() {
    const shops = await Shops_SelectAll();
    this.setState({ shops });
  }

  render() {
    const { shops } = this.state;

    return (
      <div>
        {shops.map(shop => (
          <div>{shop.ShopName}</div>
        ))}
      </div>
    );
  }
}

export default App;

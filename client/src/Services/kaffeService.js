import axios from "axios";

export async function Shops_SelectAll() {
  const resp = await axios.get("/api/kaffe");
  return resp.data;
}

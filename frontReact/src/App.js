import './App.css';
import React from 'react';
import {fetchData} from './api'
// import PaginatedItems from './components/PaginatedItems';
import { PostForm } from './components/PostForm';
class App extends React.Component {
  state = {
    data:{},
}
async componentDidMount(){
  const data = await fetchData();
  debugger;

  this.setState({ data });
}
render(){
  return (
      <div>
        <PostForm />
      </div>
  );
}
}

export default App;

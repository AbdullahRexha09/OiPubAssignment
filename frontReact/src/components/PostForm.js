import React from 'react';
import { postData } from '../api';
export class PostForm extends React.Component {
    constructor(props) {
      super(props);
      this.state = {value: ''};
  
      this.handleChange = this.handleChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
    }
  
    handleChange(event) {
      this.setState({[event.target.name] : event.target.value
        });
    }
  
    async handleSubmit(event) {
        debugger;
      alert('A name was submitted: ' + this.state.value);
     await postData(this.state);
      event.preventDefault();
    }
  
    render() {
      return (
        <form onSubmit={this.handleSubmit}>
        <label>Article publcation</label>
        <br/>
          <label>
            Title:
            <input type="text" name="Title" value={this.state.title} onChange={this.handleChange} />
          </label>
          <label>
            DatePublished:
            <input type="datetime" name="DatePublished" value={this.state.datePublished} onChange={this.handleChange} />
          </label>
          <label>
            ReferenceCount:
            <input type="text" name="ReferenceCount" value={this.state.referenceCount} onChange={this.handleChange} />
          </label>
          <label>
            NumberOfCitation:
            <input type="text" name="NumberOfCitation" value={this.state.numberOfCitation} onChange={this.handleChange} />
          </label>
          <input type="submit" value="Submit" />
        </form>
      );
    }
  }
import axios from 'axios';

const url = 'https://localhost:44331';

export const fetchData = async()=>{
    try{
        debugger;
        const {data} = await axios.get(url);
        console.log(data);
        return data;
    }
    catch(error){

    }
}
export const postData = async(body)=>{
    try{
        debugger;
        const {data} = await axios.post(url, body);
        console.log(data);
        return data;
    }
    catch(error){

    }
}
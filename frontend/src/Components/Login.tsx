import { useState } from 'react'
import { redirect } from 'react-router-dom'


//RECENT DTO EDIT
interface UsernameDto {
    Id: number
    UserName: string
}
//RECENT DTO EDIT
interface UsernameAndPasswordDto {
    Id: number
    UserName: string
    Password: string
}






async function LoginAPICall(): Promise<UsernameDto> {
    var dto = {} as UsernameAndPasswordDto // Empty brackets create empty object and 'as" keyword marks this as this type of object
    
    var response = await fetch("localhost:5128/User/Login", { method: "POST", body: JSON.stringify(dto)})
    return response.json()
}

async function LoginRequest() {
   var user = await LoginAPICall()
   if(!user){

   }
   redirect('/user');
}

async function NewUserRequest(): Promise<UsernameDto> {
    var dto = {} as UsernameAndPasswordDto // Empty brackets create empty object and 'as" keyword marks this as this type of object
    
    var response = await fetch("localhost:5128/User", { method: "POST", body: JSON.stringify(dto)})
    return response.json()
}


function App() {
    const [count, setCount] = useState(0)

    return (
        <div className="LoginWrapper">
            <div className="LoginSection">
                <p>Login to start chatting! :D</p>
                <input placeholder='Username'></input>
                <input placeholder='Password'></input>
                <button className="LoginButton" onClick={LoginRequest}></button>
            </div>
            <div className="RegisterSection">
                <p>Dont have an account yet? Register here!</p>
                <input placeholder='Username'></input>
                <input placeholder='Password'></input>
                <button className="RegisterButton" onClick={LoginRequest}></button>
            </div>
        </div>
    )
}
export default App

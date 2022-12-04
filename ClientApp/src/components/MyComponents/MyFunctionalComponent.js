import React, { useEffect, useState } from "react";

let MyFunctionalComponent = (props) => {

    let x = () => {
        alert("X");
    }

    let y = () => {
        alert("Y");
    }

    useEffect(() => {
        x();
        return () => {
            y();
        }
    }, []);

    const [age, setAge] = useState(22);

    let plus = () => {
        setAge(age + 1);
    }

    let minus = () => {
        setAge(age - 1);
    }

    const changeEvent = (e) => {
        setAge(parseInt(e.target.value));
    }

    {/* Form*/ }
    let [name, setName] = useState("Nebojsa");
    let nameChange = (e) => {
        setName(e.target.value);
    }
    let handleSubmit = () => {
        alert(`Form submitted Name: ${name}`)
    }

    return (
        <div>
            <h1>Functional component</h1>
            <h2>{props.name ? props.name : "Noname"}</h2>

            <h2>Age: </h2><input type="number" value={age} onChange={ changeEvent }/>
            <button onClick={plus}>+</button>
            <button onClick={minus}>-</button>

            {
                (() => {
                    switch (age) {
                        case 1: return(<p>Age is {age}</p>)
                        case 2: return (<p>Age is {age}</p>)
                        case 3: return (<p>Age is {age}</p>)
                    }
                    
                })()
            }
            <form onSubmit={handleSubmit}>
                <label>Name:<input type="text" value={name} onChange={nameChange}/></label>
                    <input type="submit" value="submit" />
            </form>
        </div>
    );
}

export default MyFunctionalComponent;
import { useEffect, useState } from 'react';
import './App.css';

interface Inventory {
    id: number;
    productName: string;
    quantity: number;
    measurementUnit: string;
    expirationDate: string;
}

function App() {
    const [inventories, setInventories] = useState<Inventory[]>();
    //const [inputId, setInputId] = useState<number>(1);

    useEffect(() => {
        //populateInventoryData();
        searchById(5);
    }, []);

    const contents = inventories === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Item</th>
                    <th>Qty</th>
                    <th>M.U.</th>
                    <th>Expiration date</th>
                </tr>
            </thead>
            <tbody>
                {inventories.map(item =>
                    <tr key={item.id}>
                        <td>{item.productName}</td>
                        <td>{item.quantity}</td>
                        <td>{item.measurementUnit}</td>
                        <td>{item.expirationDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Pantry inventory</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateInventoryData() {
        const response = await fetch('weatherforecast');
        if (response.ok) {
            const data = await response.json();
            console.log(data);
            setInventories(data);
        }
    }

    async function searchById(id: number) {
        const response = await fetch(`weatherforecast/${id}`);
        if (response.ok) {
            const data = await response.json();
            setInventories([data]);
        }
    }
}

export default App;
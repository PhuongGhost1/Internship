import React, { useState } from 'react';
import './PaymentDetail.css';
import visaLogo from '../../../../assets/visaLogo.png';
import paypalLogo from '../../../../assets/paypalLogo.png';

function PaymentDetail() {
    const [paymentMethod, setPaymentMethod] = useState('');
    const [cardNumber, setCardNumber] = useState('');
    const [cardName, setCardName] = useState('');
    const [expDate, setExpDate] = useState('');
    const [cvv, setCvv] = useState('');
    const [errors, setErrors] = useState({});

    const billItems = [
        { id: 1, name: 'Learning Python', price: 20 },
        { id: 2, name: 'Machine Learning. Data Scientist', price: 20 },
    ];

    const handleSubmit = (event) => {
        event.preventDefault();
        const newErrors = {};

        const cardNumberPattern = /^\d{10,}$/;
        if (!cardNumberPattern.test(cardNumber)) {
            newErrors.cardNumber = 'Card number must be at least 10 digits.';
        }

        const cardNamePattern = /^[A-Za-z\s]{8,}$/;
        if (!cardNamePattern.test(cardName)) {
            newErrors.cardName = 'Name on card must be at least 8 characters and contain only letters.';
        }

        const cvvPattern = /^\d{3,4}$/;
        if (!cvvPattern.test(cvv)) {
            newErrors.cvv = 'CVV must be 3 or 4 digits.';
        }

        setErrors(newErrors);

        if (Object.keys(newErrors).length === 0) {
            console.log({
                paymentMethod,
                cardNumber,
                cardName,
                expDate,
                cvv,
            });
            alert('Payment details submitted!');
        }
    };

    return (
        <div id="payment-detail">
            <div className="form-input">
                <form onSubmit={handleSubmit} className='form-css'>
                    <div className="title">
                        <h1>Payment Method</h1>
                    </div>

                    <div className="payment-option">
                        <h4>Select Payment Option</h4>
                        <div className="option-container">
                            <div className="option">
                                <input
                                    type="radio"
                                    id="visa"
                                    name="paymentMethod"
                                    value="Visa"
                                    checked={paymentMethod === 'Visa'}
                                    onChange={(e) => setPaymentMethod(e.target.value)}
                                    required
                                />
                                <label htmlFor="visa">
                                    <img src={visaLogo} alt="Visa" className="logo" />
                                </label>
                            </div>
                            <div className="option">
                                <input
                                    type="radio"
                                    id="paypal"
                                    name="paymentMethod"
                                    value="PayPal"
                                    checked={paymentMethod === 'PayPal'}
                                    onChange={(e) => setPaymentMethod(e.target.value)}
                                    required
                                />
                                <label htmlFor="paypal">
                                    <img src={paypalLogo} alt="PayPal" className="logo" />
                                </label>
                            </div>
                        </div>
                    </div>

                    {paymentMethod === 'Visa' && (
                        <>
                            <div className="card-number">
                                <label htmlFor="card-number">
                                    <h4>Card Number</h4>
                                </label>
                                <input
                                    type="text"
                                    id="card-number"
                                    name="cardnumber"
                                    value={cardNumber}
                                    onChange={(e) => setCardNumber(e.target.value)}
                                    required
                                    pattern="\d{10,}"
                                    title="Card number must be at least 10 digits."
                                />
                                {errors.cardNumber && <p className="error">{errors.cardNumber}</p>}
                            </div>

                            <div className="card-name">
                                <label htmlFor="card-name">
                                    <h4>Name on Card</h4>
                                </label>
                                <input
                                    type="text"
                                    id="card-name"
                                    name="cardname"
                                    value={cardName}
                                    onChange={(e) => setCardName(e.target.value)}
                                    required
                                    pattern="[A-Za-z\s]{8,}"
                                    title="Name on card must be at least 8 characters and contain only letters."
                                />
                                {errors.cardName && <p className="error">{errors.cardName}</p>}
                            </div>

                            <div className="card-info">
                                <div className="expdate">
                                    <label htmlFor="exp-date">
                                        <h4>Expiration Date</h4>
                                    </label>
                                    <input
                                        type="date"
                                        id="exp-date"
                                        name="expdate"
                                        value={expDate}
                                        onChange={(e) => setExpDate(e.target.value)}
                                        required
                                    />
                                </div>
                                <div className="cvv-detail">
                                    <label htmlFor="cvv">
                                        <h4>CVV</h4>
                                    </label>
                                    <input
                                        type="text"
                                        id="cvv"
                                        name="cvv"
                                        value={cvv}
                                        onChange={(e) => setCvv(e.target.value)}
                                        required
                                        pattern="\d{3,4}"
                                        title="CVV must be 3 or 4 digits."
                                    />
                                    {errors.cvv && <p className="error">{errors.cvv}</p>}
                                </div>
                            </div>
                        </>
                    )}

                    <div className="submit">
                        <button type="submit">Submit</button>
                    </div>
                </form>
            </div>
            <div className="bill-container">
                <div className="bill">
                    <div className="bill-header">
                        <h1>Summary</h1>
                    </div>
                    {billItems.map((item) => (
                        <div key={item.id} className="bill-body">
                            <p className="text1">{item.name}</p>
                            <p className="text2">${item.price}</p>
                        </div>
                    ))}
                    <div className="bill-footer">
                        <h4>Total</h4>
                        <h4>${billItems.reduce((total, item) => total + item.price, 0)}</h4>
                    </div>
                    <div className="submit">
                        <button type="button" onClick={() => alert('Payment confirmed!')}>Confirm</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default PaymentDetail;

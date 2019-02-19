pragma solidity >=0.4.22 <0.6.0;

contract Lotery  {
    
    address payable[] public tokens;
    uint public loteryEnd;
    uint public tokenPrice;
    
    uint public prize;
    uint public commision;
    uint public commisionBank;
    
    address payable public winner;
    uint public winedTokenNum;
    
    address payable private owner;
    
    event LoteryEnded(address winner, uint winedTokenNum, uint amount);
    event TokenBuyed(address buyer, uint quantity);
    
    constructor(uint _loteryEnd, uint _tokenPrice, uint _commision) public payable{
        require (_tokenPrice > _commision);
        loteryEnd = _loteryEnd;
        tokenPrice = _tokenPrice;
        commision = _commision;
        owner = msg.sender;
        prize += msg.value;
    }
    
    function buyToken() public payable {
        require (msg.value >= tokenPrice);
        uint remnant = msg.value % tokenPrice;
        uint quantity = (msg.value - remnant) / tokenPrice;
        
        for (uint8 i=0; i < quantity; i++){
            tokens.push(msg.sender);
        }
        
        prize += msg.value - remnant - (commision * quantity);
        commisionBank += commision * quantity;
        
        msg.sender.transfer(remnant);
        
        emit TokenBuyed(msg.sender, quantity);
    }
    
    function getCount() public view returns(uint count) {
        return tokens.length;
    }
    
    function getTimeToEnd() public view returns(uint time){
        if (now > loteryEnd) return 0;
        return loteryEnd - now;
    }
    
    function random() private view returns (uint number) {
        return (uint(blockhash(block.number-1)) - now) % tokens.length;
    }
    
    function endLotery() public {
        require (msg.sender == owner);
        require (now > loteryEnd);
        winedTokenNum = random();
        winner = tokens[winedTokenNum];
        winner.transfer(prize);
        owner.transfer(commisionBank);
        emit LoteryEnded(winner, winedTokenNum, prize);
    }
}
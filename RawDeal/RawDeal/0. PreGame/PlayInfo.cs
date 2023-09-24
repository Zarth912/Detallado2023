using RawDealView.Formatters;

namespace RawDeal._1._InGame;

public class PlayInfo:IViewablePlayInfo
{
    public IViewableCardInfo CardInfo { get; }
    public string PlayedAs { get; }

    public PlayInfo(IViewableCardInfo cardInfo, string playedAs)
    {
        CardInfo = cardInfo;
        PlayedAs = playedAs;
    }
}